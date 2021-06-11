package com.example.mobile

import android.content.Context
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.AdapterView
import android.widget.ArrayAdapter
import com.example.mobile.controllers.ContainerController
import com.example.mobile.fragments.MachineContainerListFragment
import com.example.mobile.models.container.Container
import kotlinx.android.synthetic.main.activity_machine_container_list.*
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class MachineContainerActivity() : AppCompatActivity() {
    val containers = listOf(
        Container(1, 1, "Name", 10.0),
        Container(12, 2, "Name1", 11.0)
    )

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_machine_container_list)

        val sharedPref = this.getSharedPreferences("Authorization", Context.MODE_PRIVATE)
        val machinesId = arrayOf(1, 2, 3, 4)
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
                val machineIdSelected = machinesId[position]

                val token = sharedPref.getString("AccessToken", "")!!

                val controller = ContainerController(token)
                controller.GetAllMachineContainer(object : Callback<List<Container>> {
                    override fun onResponse(
                        call: Call<List<Container>>,
                        response: Response<List<Container>>
                    ) {
                        if (response.isSuccessful) {
                            var fragment =
                                supportFragmentManager.findFragmentById(R.id.container_fragment) as MachineContainerListFragment

                            fragment.setContainers(response.body()!!)
                        }
                    }

                    override fun onFailure(call: Call<List<Container>>, t: Throwable) {
                        TODO("Not yet implemented")
                    }
                }, machineIdSelected)
            }
        }

        val fm = supportFragmentManager
        var fragment = fm.findFragmentById(R.id.container_fragment) as? MachineContainerListFragment

        if (fragment == null) {
            fragment = MachineContainerListFragment(token)
            fm.beginTransaction()
                .add(R.id.container_fragment, fragment)
                .commit()
        }

    }
}