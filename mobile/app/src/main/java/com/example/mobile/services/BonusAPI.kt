package com.example.mobile.services

import com.example.mobile.models.container.BonusModel
import com.example.mobile.models.container.Container
import retrofit2.Call
import retrofit2.http.GET
import retrofit2.http.Path

interface BonusAPI {
    @GET("/api/user/bonus")
    fun getUserBonus(): Call<BonusModel>
}