package com.example.mobile.controllers

import com.example.mobile.models.machine.Machine
import com.example.mobile.services.MachineAPI
import okhttp3.OkHttpClient
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Retrofit
import retrofit2.converter.moshi.MoshiConverterFactory

class MachineController(private val token: String) : BaseController()  {
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

    fun getAllMachines(callback: Callback<List<Machine>>) {
        val call: Call<List<Machine>> = containerService.GetAllMachines()

        call.enqueue(callback)
    }
}