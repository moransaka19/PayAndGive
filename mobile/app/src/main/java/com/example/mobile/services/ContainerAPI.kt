package com.example.mobile.services


import com.example.mobile.models.container.Container
import retrofit2.Call
import retrofit2.http.GET
import retrofit2.http.Path
import retrofit2.http.Query

interface ContainerAPI {
    @GET("/api/containers/machines/{id}")
    fun GetAllMachineContainers(@Path("id") id: Int): Call<List<Container>>
}