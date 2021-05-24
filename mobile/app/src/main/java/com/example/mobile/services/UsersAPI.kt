package com.example.mobile.services

import com.example.mobile.pojo.*
import retrofit2.Call
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.Headers
import retrofit2.http.POST

interface UsersAPI {
    @GET("/api/auth/current")
    fun getCurrentUser(): Call<CurrentUserModel>

    @POST("/api/auth/login")
    fun login(@Body model: LoginModel): Call<AccessTokenModel>

    @POST("/api/auth/register")
    fun register(@Body model: RegisterModel): Call<AccessTokenModel>

    @POST("/api/auth/add-money")
    fun addMoney(@Body model: MoneyModel): Call<Unit>

    @POST("/api/machines/2/make-purchase")
    fun makePurchase(@Body model: MakePurchaseModel): Call<Unit>
}