package com.example.mobile

import android.content.Context
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import com.example.mobile.controllers.UserController
import com.example.mobile.models.profile.CurrentUserModel
import kotlinx.android.synthetic.main.activity_profile.*
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class Profile : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_profile)

        val sharedPref = this.getSharedPreferences("Authorization", Context.MODE_PRIVATE)
        val controller = UserController(sharedPref)
        val context = this

        controller.getCurrentUser(object: Callback<CurrentUserModel> {
            override fun onFailure(call: Call<CurrentUserModel>, t: Throwable) {
                var message = "Test"
                if (t.message != null){
                    message += t.message
                }
                Log.println(Log.INFO, "TEST", message)
            }

            override fun onResponse(call: Call<CurrentUserModel>, response: Response<CurrentUserModel>) {
                if (response.isSuccessful) {
                    val model = response.body()

                    profile_login_text.text = model!!.login
                    profile_name_text.text = model.name
                    profile_money_text.text = model.money.toString()
                }
                else{
                    val intent = Intent(context, Login::class.java)
                    startActivity(intent)
                }
            }
        })

        go_add_money.setOnClickListener{
            val intent = Intent(this, AddMoneyActivity::class.java)
            startActivity(intent)
        }

        go_make_purchase.setOnClickListener{
            val intent = Intent(this, MachineContainerActivity::class.java)
            startActivity(intent)
        }
    }
}