package com.example.mobile.models.container

data class Container(
    val id: Int,
    val machineId: Int,
    val name: String,
    val price: Double,
    val isAdded: Boolean = false
)