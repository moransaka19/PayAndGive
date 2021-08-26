package com.example.mobile.controllers

import android.content.SharedPreferences
import com.example.mobile.models.login.AccessTokenModel
import com.example.mobile.models.preorder.AddPreorderModel
import com.example.mobile.models.preorder.Preorder
import com.example.mobile.services.PreorderAPI
import okhttp3.OkHttpClient
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Retrofit
import retrofit2.converter.moshi.MoshiConverterFactory

class PreorderController(private val sharedPref: SharedPreferences) : BaseController() {
    private val token = sharedPref.getString("AccessToken", String()) ?: ""

    private val preorderService = Retrofit.Builder()
        .baseUrl(BASE_URL)
        .addConverterFactory(MoshiConverterFactory.create())
        .client(OkHttpClient().newBuilder().addInterceptor { chain ->
            chain.proceed(
                chain.request().newBuilder().addHeader("Authorization", "Bearer $token").build()
            )
        }.build())
        .build()
        .create(PreorderAPI::class.java)

    fun addPreorder(callback: Callback<Unit>, model: AddPreorderModel) {
        val call: Call<Unit> =
            preorderService.addPreorder(model)
        call.enqueue(callback)
    }
    fun getPreorders(callback: Callback<List<Preorder>>) {
        val call: Call<List<Preorder>> =
            preorderService.getUserPreorders()
        call.enqueue(callback)
    }
}
