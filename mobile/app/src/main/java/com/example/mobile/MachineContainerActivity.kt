package com.example.mobile

import android.content.Context
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.ViewGroup
import android.widget.ArrayAdapter
import androidx.fragment.app.Fragment
import androidx.fragment.app.add
import androidx.fragment.app.commit
import com.example.mobile.fragments.ContainerFragment
import com.example.mobile.fragments.ItemFragment
import com.example.mobile.fragments.MyItemRecyclerViewAdapter
import kotlinx.android.synthetic.main.activity_machine_container.*

class MachineContainerActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_machine_container)

        val sharedPref = this.getSharedPreferences("Authorization", Context.MODE_PRIVATE)
        val context = this
        val machinesId = arrayOf(1, 2, 3, 4)
        val containers = listOf("asdlfjasf", "sdfsdf", "asdf")

        val machinesAdapter = ArrayAdapter<Int>(this, android.R.layout.simple_spinner_item, machinesId)
        machine_spinner.adapter = machinesAdapter

        val bundle = Bundle()

        bundle.putString("one", "1")

        list.adapter = MyItemRecyclerViewAdapter(containers)



//        val model = MakePurchaseModel(containersId, 1)
//        val controller = UserController(sharedPref)
//        container_make_purchase.setOnClickListener{
//            controller.makePurchase(object : Callback<Unit> {
//                override fun onResponse(call: Call<Unit>, response: Response<Unit>) {
//                    if (response.isSuccessful) {
//                        val intent = Intent(context, Profile::class.java)
//                        startActivity(intent)
//                    }
//                }
//
//                override fun onFailure(call: Call<Unit>, t: Throwable) {
//                    TODO("Not yet implemented")
//                }
//            }, model)
//        }

    }
}