package com.example.mobile.services

import com.example.mobile.pojo.AccessTokenModel
import com.example.mobile.pojo.CurrentUserModel
import com.example.mobile.pojo.LoginModel
import com.example.mobile.pojo.RegisterModel
import retrofit2.Call
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.Headers
import retrofit2.http.POST

interface UsersAPI {
    @Headers("Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxIiwidW5pcXVlX25hbWUiOiJBZG1pbiIsInJvbGUiOiJBZG1pbiIsImV4cCI6MTYyMDkwMzEwNSwiaXNzIjoiYXV0aFNlcnZlciIsImF1ZCI6InJlc291cnNlU2VydmVyIn0.VjKU4xiH3WYkSiJT7qXRE7nYPMeAp3cbv5-ljzQiae0")
    @GET("/api/auth/current")
    fun getCurrentUser(): Call<CurrentUserModel>

    @POST("/api/auth/login")
    fun login(@Body model: LoginModel): Call<AccessTokenModel>

    @POST("/api/auth/register")
    fun register(@Body model: RegisterModel): Call<AccessTokenModel>

}