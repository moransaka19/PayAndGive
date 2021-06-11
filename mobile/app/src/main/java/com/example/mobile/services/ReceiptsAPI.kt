package com.example.mobile.services

import com.example.mobile.models.recept.AddReceiptModel
import retrofit2.Call
import retrofit2.http.Body
import retrofit2.http.POST
import javax.security.auth.callback.Callback

interface ReceiptsAPI {
    @POST("/api/receipts")
    fun addReceipt(@Body model: AddReceiptModel): Call<Unit>
}