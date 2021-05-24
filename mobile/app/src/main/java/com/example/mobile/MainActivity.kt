package com.example.mobile

import android.content.Context
import android.content.Intent
import android.os.Bundle
import android.util.Log
import androidx.appcompat.app.AppCompatActivity
import com.example.mobile.controllers.UserController
import com.example.mobile.pojo.CurrentUserModel
import kotlinx.android.synthetic.main.activity_main.*
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response


class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val sharedPref = this.getSharedPreferences("Authorization", Context.MODE_PRIVATE)

        val token = sharedPref.getString("AccessToken", String())
        if (token != null){
            val intent = Intent(this, Profile::class.java)
            startActivity(intent)
        }
        else{
            val intent = Intent(this, Login::class.java)
            startActivity(intent)
        }

        text.setText(token)
    }
}
