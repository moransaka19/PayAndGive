package com.example.mobile

import android.content.Context
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.AdapterView
import android.widget.ArrayAdapter
import com.example.mobile.controllers.EatController
import com.example.mobile.controllers.PreorderController
import com.example.mobile.models.container.Eat
import com.example.mobile.models.preorder.AddPreorderModel
import com.google.android.material.snackbar.Snackbar
import kotlinx.android.synthetic.main.activity_add_preorder.*
import kotlinx.android.synthetic.main.machine_container_list.*
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class AddPreorder : AppCompatActivity() {
    lateinit var selectedEat: Eat

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_add_preorder)

        val sharedPref = this.getSharedPreferences("Authorization", Context.MODE_PRIVATE)
        val token = sharedPref.getString("AccessToken", "")!!
        val context = this

        val eatController = EatController(sharedPref)
        eatController.getEats(object : Callback<List<Eat>> {
            override fun onResponse(
                call: Call<List<Eat>>,
                response: Response<List<Eat>>
            ) {
                if (response.isSuccessful) {
                    val eats = response.body()!!
                    val eatNames = eats.map { it.name }
                    val eatsAdapter = ArrayAdapter<String>(
                        context,
                        android.R.layout.simple_spinner_item,
                        eatNames
                    )
                    eats_spiner.adapter = eatsAdapter
                    eats_spiner.onItemSelectedListener =
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
                                selectedEat = eats.first { it.name == eatNames[position] }
                                val eatId: ArrayList<Int> = ArrayList()
                                eatId.add(selectedEat.id)
                                val addPreorderModel = AddPreorderModel(eatId)
                                val preorderController = PreorderController(sharedPref)
                                send_eat_button.setOnClickListener {
                                    preorderController.addPreorder((object : Callback<Unit> {
                                        override fun onResponse(
                                            call: Call<Unit>,
                                            response: Response<Unit>
                                        ) {
                                            if (response.isSuccessful) {
                                                val snackbar = Snackbar.make(it, "Thanks for preorder", Snackbar.LENGTH_LONG)
                                                snackbar.show()
                                                val intent = Intent(context, Preorders::class.java)
                                                startActivity(intent)
                                            }
                                        }

                                        override fun onFailure(call: Call<Unit>, t: Throwable) {
                                            TODO("Not yet implemented")
                                        }
                                    }), addPreorderModel)
                                }
                            }
                        }
                }
            }

            override fun onFailure(call: Call<List<Eat>>, t: Throwable) {
                TODO("Not yet implemented")
            }
        })
    }
}


