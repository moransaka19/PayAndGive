package com.example.mobile

import android.content.Context
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.AdapterView
import android.widget.ArrayAdapter
import androidx.appcompat.app.AppCompatActivity
import com.example.mobile.controllers.MachineController
import com.example.mobile.models.container.Container
import com.example.mobile.models.machine.Machine
import com.example.mobile.services.ContainerAdapter
import kotlinx.android.synthetic.main.machine_container_list.*
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class MachineContainerActivity() : AppCompatActivity() {
    var machines: List<Machine> = ArrayList()
    var machinesId: List<Int> = ArrayList()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.machine_container_list)

        val sharedPref = this.getSharedPreferences("Authorization", Context.MODE_PRIVATE)

        val token = sharedPref.getString("AccessToken", "")!!

        val controller = MachineController(token)
        controller.getAllMachines(object : Callback<List<Machine>> {
            override fun onResponse(
                call: Call<List<Machine>>,
                response: Response<List<Machine>>
            ) {
                if (response.isSuccessful) {
                    machines = response.body()!!
                    machinesId = machines.map { it.id }
                    Log.println(Log.INFO, "geting-machines", machines.size.toString())
                }
            }

            override fun onFailure(call: Call<List<Machine>>, t: Throwable) {
                Log.println(Log.DEBUG, "machine-containers", "Fail: ")
            }
        })
    }

    override fun onStart() {
        val machinesAdapter =
            ArrayAdapter<Int>(this, android.R.layout.simple_spinner_item, machinesId)
        machine_spinner.adapter = machinesAdapter
        machine_spinner.onItemSelectedListener = object : AdapterView.OnItemSelectedListener {
            override fun onNothingSelected(parent: AdapterView<*>?) {
                TODO("Not yet implemented")
            }

            override fun onItemSelected(
                parent: AdapterView<*>?,
                view: View?,
                position: Int,
                id: Long
            ) {
                val machineIdSelected = machines[position].id
                updateContainers(machines[machineIdSelected].containers)
            }
        }

        super.onStart()
    }

    fun updateContainers(containers: List<Container>){
        machine_container_recycle_view.adapter = ContainerAdapter(containers)
    }
}