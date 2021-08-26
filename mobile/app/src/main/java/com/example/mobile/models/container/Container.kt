package com.example.mobile.models.container

data class Container(
    val id: Int,
    val machineId: Int,
    val eat: Eat,
    val isAdded: Boolean = false
)