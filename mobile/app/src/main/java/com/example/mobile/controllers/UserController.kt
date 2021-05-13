package com.example.mobile.controllers

import com.example.mobile.pojo.AccessTokenModel
import com.example.mobile.pojo.CurrentUserModel
import com.example.mobile.pojo.LoginModel
import com.example.mobile.pojo.RegisterModel
import com.example.mobile.services.UsersAPI
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Retrofit
import retrofit2.converter.moshi.MoshiConverterFactory

class UserController {
    val BASE_URL = "https://payandgive.azurewebsites.net/"

    fun getCurrentUser(callback: Callback<CurrentUserModel>) {
        val retrofit = Retrofit.Builder()
            .baseUrl(BASE_URL)
            .addConverterFactory(MoshiConverterFactory.create())
            .build()
        val userService: UsersAPI = retrofit.create(UsersAPI::class.java)
        val call: Call<CurrentUserModel> =
            userService.getCurrentUser()
        call.enqueue(callback)
    }

    fun login(callback: Callback<AccessTokenModel>, model: LoginModel){
        val retrofit = Retrofit.Builder()
            .baseUrl(BASE_URL)
            .addConverterFactory(MoshiConverterFactory.create())
            .build()
        val userService: UsersAPI = retrofit.create(UsersAPI::class.java)
        val call: Call<AccessTokenModel> =
            userService.login(model)
        call.enqueue(callback)
    }

    fun register(callback: Callback<AccessTokenModel>, model: RegisterModel){
        val retrofit = Retrofit.Builder()
            .baseUrl(BASE_URL)
            .addConverterFactory(MoshiConverterFactory.create())
            .build()
        val userService: UsersAPI = retrofit.create(UsersAPI::class.java)
        val call: Call<AccessTokenModel> =
            userService.register(model)
        call.enqueue(callback)
    }
}