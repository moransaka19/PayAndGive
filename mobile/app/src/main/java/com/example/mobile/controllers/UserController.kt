package com.example.mobile.controllers

import android.content.SharedPreferences
import com.example.mobile.models.login.AccessTokenModel
import com.example.mobile.models.profile.CurrentUserModel
import com.example.mobile.models.login.LoginModel
import com.example.mobile.models.login.RegisterModel
import com.example.mobile.models.profile.MakePurchaseModel
import com.example.mobile.models.profile.MoneyModel
import com.example.mobile.services.UsersAPI
import okhttp3.OkHttpClient
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Retrofit
import retrofit2.converter.moshi.MoshiConverterFactory

class UserController(private val sharedPref: SharedPreferences) : BaseController()  {
    private val token = sharedPref.getString("AccessToken", String()) ?: ""

    private val userService = Retrofit.Builder()
        .baseUrl(BASE_URL)
        .addConverterFactory(MoshiConverterFactory.create())
        .client(OkHttpClient().newBuilder().addInterceptor { chain ->
            chain.proceed(chain.request().newBuilder().addHeader("Authorization", "Bearer $token").build())
        }.build())
        .build()
        .create(UsersAPI::class.java)
    fun getUser(callback: Callback<CurrentUserModel>) {
        val call: Call<CurrentUserModel> =
            userService.getUser()
        call.enqueue(callback)
    }

    fun getCurrentUser(callback: Callback<CurrentUserModel>) {
        val call: Call<CurrentUserModel> =
            userService.getCurrentUser()
        call.enqueue(callback)
    }

    fun login(callback: Callback<AccessTokenModel>, model: LoginModel) {
        val call: Call<AccessTokenModel> =
            userService.login(model)
        call.enqueue(callback)
    }

    fun register(callback: Callback<AccessTokenModel>, model: RegisterModel) {
        val call: Call<AccessTokenModel> =
            userService.register(model)
        call.enqueue(callback)
    }

    fun addMoney(callback: Callback<Unit>, model: MoneyModel) {
        val call: Call<Unit> =
            userService.addMoney(model)
        call.enqueue(callback)
    }

    fun makePurchase(callback: Callback<Unit>, model: MakePurchaseModel){
        val call: Call<Unit> =
            userService.makePurchase(model)
        call.enqueue(callback)
    }
}