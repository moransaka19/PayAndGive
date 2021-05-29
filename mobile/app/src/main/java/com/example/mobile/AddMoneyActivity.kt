package com.example.mobile

import android.content.Context
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.example.mobile.controllers.UserController
import com.example.mobile.models.profile.MoneyModel
import com.example.mobile.services.JWTUtils
import kotlinx.android.synthetic.main.activity_add_money.*
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class AddMoneyActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_add_money)

        val sharedPref = this.getSharedPreferences("Authorization", Context.MODE_PRIVATE)
        val context = this
        val token = sharedPref.getString("AccessToken", String()) ?: return
        val tokenBody = JWTUtils.decoded(token)


        add_money_button.setOnClickListener {
            val controller = UserController(sharedPref)

            val money = add_money_text.text.toString().toDouble()
            val moneyModel = MoneyModel(
                tokenBody!!.sub.toInt(),
                money
            )
            controller.addMoney(object : Callback<Unit> {
                override fun onResponse(call: Call<Unit>, response: Response<Unit>) {
                    if (response.isSuccessful) {
                        val intent = Intent(context, Profile::class.java)
                        startActivity(intent)
                    }
                }

                override fun onFailure(call: Call<Unit>, t: Throwable) {
                    TODO("Not yet implemented")
                }
            }, moneyModel)

        }
    }
}