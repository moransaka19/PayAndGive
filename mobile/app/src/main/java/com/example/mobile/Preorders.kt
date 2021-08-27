package com.example.mobile

import android.content.Context
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.mobile.controllers.PreorderController
import com.example.mobile.models.container.Container
import com.example.mobile.models.preorder.Preorder
import com.example.mobile.services.ContainerAdapter
import com.example.mobile.services.PreorderAdapter
import kotlinx.android.synthetic.main.activity_add_preorder.*
import kotlinx.android.synthetic.main.activity_preorders.*
import kotlinx.android.synthetic.main.machine_container_list.*
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class Preorders : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_preorders)

        val sharedPref = this.getSharedPreferences("Authorization", Context.MODE_PRIVATE)
        val token = sharedPref.getString("AccessToken", "")!!
        val context = this

        add_preorder.setOnClickListener {
            val intent = Intent(this, AddPreorder::class.java)
            startActivity(intent)
        }

        val preorderController = PreorderController(sharedPref)
        preorderController.getPreorders((object : Callback<List<Preorder>> {
            override fun onResponse(
                call: Call<List<Preorder>>,
                response: Response<List<Preorder>>
            ) {
                if (response.isSuccessful) {
                    val preorders = response.body()!!
                    preorder_recycler_view.layoutManager = LinearLayoutManager(context)
                    preorder_recycler_view.adapter = PreorderAdapter(preorders)
                }
            }

            override fun onFailure(call: Call<List<Preorder>>, t: Throwable) {
                TODO("Not yet implemented")
            }
        }))
    }
}