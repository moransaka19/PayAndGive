package com.example.mobile.services

import com.example.mobile.models.container.Eat
import retrofit2.Call
import retrofit2.http.GET

interface EatAPI {
    @GET("/api/eats")
    fun getEats(): Call<List<Eat>>
}