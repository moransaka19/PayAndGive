package com.example.mobile

import android.content.Context
import android.content.Intent
import android.os.Bundle
import android.util.Log
import androidx.appcompat.app.AppCompatActivity
import com.example.mobile.controllers.UserController
import com.example.mobile.models.login.AccessTokenModel
import com.example.mobile.models.login.LoginModel
import kotlinx.android.synthetic.main.activity_login.*
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response


class Login : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login)

        val sharedPref = this.getSharedPreferences("Authorization", Context.MODE_PRIVATE)
        login_button.setOnClickListener{
            val login = login_text.text.toString()
            val password = password_text.text.toString()

            val context = this
            val loginModel =
                LoginModel(login, password)

            val userController = UserController(sharedPref)
            userController.login(object: Callback<AccessTokenModel> {
                override fun onFailure(call: Call<AccessTokenModel>, t: Throwable) {
                    var message = "Test"
                    if (t.message != null){
                        message += t.message
                    }
                    Log.println(Log.INFO, "TEST", message)
                }

                override fun onResponse(call: Call<AccessTokenModel>, response: Response<AccessTokenModel>) {
                    if (response.isSuccessful) {
                        val token = response.body()?.token;
                        sharedPref.edit().putString("AccessToken", token).apply()
                        val intent = Intent(context, Profile::class.java)
                        startActivity(intent)
                    }
                }
            }, loginModel)
        }
    }
}