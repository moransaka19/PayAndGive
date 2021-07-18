package com.example.mobile.controllers

import com.example.mobile.models.container.Container
import com.example.mobile.models.machine.Machine
import com.example.mobile.services.ContainerAPI
import com.example.mobile.services.MachineAPI
import okhttp3.OkHttpClient
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Retrofit
import retrofit2.converter.moshi.MoshiConverterFactory

class MchineController(private val token: String) {
    private val BASE_URL = "https://fc40d9da33b9.ngrok.io"

    private val containerService = Retrofit.Builder()
        .baseUrl(BASE_URL)
        .addConverterFactory(MoshiConverterFactory.create())
        .client(OkHttpClient().newBuilder().addInterceptor { chain ->
            chain.proceed(
                chain.request().newBuilder().addHeader("Authorization", "Bearer $token").build()
            )
        }.build())
        .build()
        .create(MachineAPI::class.java)

    fun GetAllMachines(callback: Callback<List<Machine>>) {
        val call: Call<List<Machine>> = containerService.GetAllMachines()

        call.enqueue(callback)
    }
}