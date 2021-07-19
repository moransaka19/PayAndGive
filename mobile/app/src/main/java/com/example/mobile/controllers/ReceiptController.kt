package com.example.mobile.controllers

import com.example.mobile.models.container.Container
import com.example.mobile.models.recept.AddReceiptModel
import com.example.mobile.services.ContainerAPI
import com.example.mobile.services.ReceiptsAPI
import okhttp3.OkHttpClient
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Retrofit
import retrofit2.converter.moshi.MoshiConverterFactory

class ReceiptController(private val token: String) : BaseController() {
    private val receiptService = Retrofit.Builder()
        .baseUrl(BASE_URL)
        .addConverterFactory(MoshiConverterFactory.create())
        .client(OkHttpClient().newBuilder().addInterceptor { chain ->
            chain.proceed(
                chain.request().newBuilder().addHeader("Authorization", "Bearer $token").build()
            )
        }.build())
        .build()
        .create(ReceiptsAPI::class.java)

    fun addReceipt(callback: Callback<Unit>, model: AddReceiptModel) {
        val call: Call<Unit> = receiptService.addReceipt(model)

        call.enqueue(callback)
    }
}