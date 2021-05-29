package com.example.mobile.models

import com.beust.klaxon.*

private val klaxon = Klaxon()

data class JwtToken (
    val sub: String,

    @Json(name = "unique_name")
    val uniqueName: String
) {
    public fun toJson() = klaxon.toJsonString(this)

    companion object {
        public fun fromJson(json: String): JwtToken? = klaxon.parse<JwtToken>(json)
    }
}