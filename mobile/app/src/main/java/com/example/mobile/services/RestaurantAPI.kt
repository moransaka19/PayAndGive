package com.example.mobile.services

import com.example.mobile.models.recept.AddReceiptModel
import com.example.mobile.models.restaurant.RestaurantModel
import retrofit2.Call
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST

interface RestaurantAPI {
    @GET("/api/restaurants/google-map")
    fun addReceipt(): Call<List<RestaurantModel>>

}