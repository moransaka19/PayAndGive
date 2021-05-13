package com.example.mobile

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

        var testMessage = "";

        val userController = UserController()
        userController.start(object : Callback<CurrentUserModel> {
            override fun onFailure(call: Call<CurrentUserModel>, t: Throwable) {
                var message = "Test"
                if (t.message != null){
                    message += t.message
                }
                Log.println(Log.INFO, "TEST", message)
            }

            override fun onResponse(call: Call<CurrentUserModel>, response: Response<CurrentUserModel>) {
                if (response.isSuccessful) {
                    println(response.body()?.login)
                    var message = ""
                    message += response.body()?.login
                    testMessage = message
                } else {
                    println(response.errorBody())
                }
            }
        })

        text.setText(testMessage)
    }
}
