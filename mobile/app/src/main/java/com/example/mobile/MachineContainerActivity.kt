package com.example.mobile

import android.content.Context
import android.content.Intent
import android.content.SharedPreferences
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.AdapterView
import android.widget.ArrayAdapter
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.mobile.controllers.ContainerController
import com.example.mobile.controllers.MachineController
import com.example.mobile.controllers.ReceiptController
import com.example.mobile.models.container.Container
import com.example.mobile.models.machine.Machine
import com.example.mobile.models.recept.AddReceiptModel
import com.example.mobile.services.ContainerAdapter
import kotlinx.android.synthetic.main.machine_container_list.*
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class MachineContainerActivity() : AppCompatActivity() {
    lateinit var sharedPref: SharedPreferences
    lateinit var token: String
    lateinit var context: Context
    var machines: List<Machine> = ArrayList()
    var machinesId: List<Int> = ArrayList()
    lateinit var containerController: ContainerController
    var selecdedMachineId: Int = 1

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.machine_container_list)

        sharedPref = this.getSharedPreferences("Authorization", Context.MODE_PRIVATE)
        token = sharedPref.getString("AccessToken", "")!!
        context = this
        containerController = ContainerController(token)

        val controller = MachineController(token)
        controller.getAllMachines(object : Callback<List<Machine>> {
            override fun onResponse(
                call: Call<List<Machine>>,
                response: Response<List<Machine>>
            ) {
                if (response.isSuccessful) {
                    machinesId = response.body()!!.map { it.id }
                    Log.println(Log.INFO, "geting-machines", machines.size.toString())

                    val machinesAdapter =
                        ArrayAdapter<Int>(context, android.R.layout.simple_spinner_item, machinesId)
                    machine_spinner.adapter = machinesAdapter
                    machine_spinner.onItemSelectedListener =
                        object : AdapterView.OnItemSelectedListener {
                            override fun onNothingSelected(parent: AdapterView<*>?) {
                                TODO("Not yet implemented")
                            }

                            override fun onItemSelected(
                                parent: AdapterView<*>?,
                                view: View?,
                                position: Int,
                                id: Long
                            ) {
                                updateContainers(machinesId[position])
                                selecdedMachineId = position
                            }
                        }
                }
            }

            override fun onFailure(call: Call<List<Machine>>, t: Throwable) {
                Log.println(Log.DEBUG, "machine-containers", "Fail: ")
            }
        })

        buy_button.setOnClickListener {
            val containers =
                ((machine_container_recycle_view.adapter) as ContainerAdapter).checkedContainers.map { it.id }
            val addReceiptModel = AddReceiptModel(containers)

            val receiptController = ReceiptController(token)
            receiptController.addReceipt(object : Callback<Unit> {
                override fun onResponse(
                    call: Call<Unit>,
                    response: Response<Unit>
                ) {
                    if (response.isSuccessful) {
                        val intent = Intent(context, Profile::class.java)
                        startActivity(intent)
                    }
                }

                override fun onFailure(p0: Call<Unit>, p1: Throwable) {
                    TODO("Not yet implemented")
                }
            }, addReceiptModel)

        }
    }

    fun updateContainers(id: Int) {

        containerController.GetAllMachineContainer(object : Callback<List<Container>> {
            override fun onResponse(
                call: Call<List<Container>>,
                response: Response<List<Container>>
            ) {
                if (response.isSuccessful) {
                    val containers = response.body()!!
                    machine_container_recycle_view.layoutManager = LinearLayoutManager(context)
                    machine_container_recycle_view.adapter = ContainerAdapter(containers)
                }
            }

            override fun onFailure(call: Call<List<Container>>, t: Throwable) {
                Log.println(Log.DEBUG, "machine-containers", "Fail: ")
            }
        }, id)

    }
}