package com.example.mobile.controllers

import android.content.SharedPreferences
import com.example.mobile.models.container.Container
import com.example.mobile.services.ContainerAPI
import okhttp3.OkHttpClient
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Retrofit
import retrofit2.converter.moshi.MoshiConverterFactory

class ContainerController(private val token: String) : BaseController()  {
    private val containerService = Retrofit.Builder()
        .baseUrl(BASE_URL)
        .addConverterFactory(MoshiConverterFactory.create())
        .client(OkHttpClient().newBuilder().addInterceptor { chain ->
            chain.proceed(
                chain.request().newBuilder().addHeader("Authorization", "Bearer $token").build()
            )
        }.build())
        .build()
        .create(ContainerAPI::class.java)

    fun GetAllMachineContainer(callback: Callback<List<Container>>, id: Int) {
        val call: Call<List<Container>> = containerService.GetAllMachineContainers(id)

        call.enqueue(callback)
    }
}