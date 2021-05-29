package com.example.mobile.services

import retrofit2.http.POST

interface RecieptsAPI {
    @POST("/api/receipts")
    fun addReceipts()
}