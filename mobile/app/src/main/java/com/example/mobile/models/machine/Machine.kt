package com.example.mobile.models.machine

import com.example.mobile.models.container.Container

class Machine(
    val id: Int,
    val state: String,
    val value: Int,
    val containers: List<Container>
)