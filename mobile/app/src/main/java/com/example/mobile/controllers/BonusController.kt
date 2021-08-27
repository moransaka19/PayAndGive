package com.example.mobile.controllers

import com.example.mobile.models.container.BonusModel
import com.example.mobile.models.container.Container
import com.example.mobile.services.BonusAPI
import com.example.mobile.services.ContainerAPI
import okhttp3.OkHttpClient
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Retrofit
import retrofit2.converter.moshi.MoshiConverterFactory

class BonusController (private val token: String) : BaseController()  {
    private val containerService = Retrofit.Builder()
        .baseUrl(BASE_URL)
        .addConverterFactory(MoshiConverterFactory.create())
        .client(OkHttpClient().newBuilder().addInterceptor { chain ->
            chain.proceed(
                chain.request().newBuilder().addHeader("Authorization", "Bearer $token").build()
            )
        }.build())
        .build()
        .create(BonusAPI::class.java)

    fun getUserBonus(callback: Callback<BonusModel>) {
        val call: Call<BonusModel> = containerService.getUserBonus()

        call.enqueue(callback)
    }
}