package com.example.mobile.services

import com.example.mobile.models.machine.Machine
import retrofit2.Call
import retrofit2.http.GET

interface MachineAPI {
    @GET("/api/machines")
    fun GetAllMachines(): Call<List<Machine>>
}