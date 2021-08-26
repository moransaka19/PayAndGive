package com.example.mobile.services

import com.example.mobile.AddPreorder
import com.example.mobile.models.container.Eat
import com.example.mobile.models.preorder.AddPreorderModel
import com.example.mobile.models.preorder.Preorder
import com.example.mobile.models.recept.AddReceiptModel
import retrofit2.Call
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST

interface PreorderAPI {
    @POST("/api/preorders")
    fun addPreorder(@Body model: AddPreorderModel): Call<Unit>
    @GET("/api/preorders/user")
    fun getUserPreorders():Call<List<Preorder>>
}