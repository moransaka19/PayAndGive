package com.example.mobile

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import com.example.mobile.controllers.UserController
import com.example.mobile.pojo.AccessTokenModel
import com.example.mobile.pojo.CurrentUserModel
import com.example.mobile.pojo.LoginModel
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class Login : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login)

        var loginModel = LoginModel(login = )

        var userController = UserController()
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

                } else {
                }
            }
        }, loginModel)
    }
}