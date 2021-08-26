package com.example.mobile.controllers

import android.content.SharedPreferences
import com.example.mobile.models.container.Eat
import com.example.mobile.models.login.AccessTokenModel
import com.example.mobile.models.login.LoginModel
import com.example.mobile.models.login.RegisterModel
import com.example.mobile.models.profile.CurrentUserModel
import com.example.mobile.models.profile.MakePurchaseModel
import com.example.mobile.models.profile.MoneyModel
import com.example.mobile.services.EatAPI
import com.example.mobile.services.UsersAPI
import okhttp3.OkHttpClient
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Retrofit
import retrofit2.converter.moshi.MoshiConverterFactory

class EatController(private val sharedPref: SharedPreferences) : BaseController()  {
    private val token = sharedPref.getString("AccessToken", String()) ?: ""

    private val eatService = Retrofit.Builder()
        .baseUrl(BASE_URL)
        .addConverterFactory(MoshiConverterFactory.create())
        .client(OkHttpClient().newBuilder().addInterceptor { chain ->
            chain.proceed(chain.request().newBuilder().addHeader("Authorization", "Bearer $token").build())
        }.build())
        .build()
        .create(EatAPI::class.java)
    fun getEats(callback: Callback<List<Eat>>) {
        val call: Call<List<Eat>> =
            eatService.getEats()
        call.enqueue(callback)
    }


}