package com.example.mobile.controllers

import com.example.mobile.models.container.BonusModel
import com.example.mobile.models.restaurant.RestaurantModel
import com.example.mobile.services.BonusAPI
import com.example.mobile.services.RestaurantAPI
import okhttp3.OkHttpClient
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Retrofit
import retrofit2.converter.moshi.MoshiConverterFactory

class RestaurantController  (private val token: String) : BaseController()  {
    private val restaurantService = Retrofit.Builder()
        .baseUrl(BASE_URL)
        .addConverterFactory(MoshiConverterFactory.create())
        .client(OkHttpClient().newBuilder().addInterceptor { chain ->
            chain.proceed(
                chain.request().newBuilder().addHeader("Authorization", "Bearer $token").build()
            )
        }.build())
        .build()
        .create(RestaurantAPI::class.java)

    fun getUserBonus(callback: Callback<List<RestaurantModel>>) {
        val call: Call<List<RestaurantModel>> = restaurantService.addReceipt()

        call.enqueue(callback)
    }
}