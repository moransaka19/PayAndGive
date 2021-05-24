package com.example.mobile.services

import android.util.Base64
import android.util.Log
import com.example.mobile.pojo.JwtToken
import java.io.UnsupportedEncodingException

object JWTUtils {
    @Throws(Exception::class)
    fun decoded(JWTEncoded: String): JwtToken? {
        val split = JWTEncoded.split("\\.".toRegex()).toTypedArray()
        return JwtToken.fromJson(getJson(split[1]))
    }

    @Throws(UnsupportedEncodingException::class)
    private fun getJson(strEncoded: String): String {
        val decodedBytes: ByteArray = Base64.decode(strEncoded, Base64.URL_SAFE)
        return String(decodedBytes, charset("UTF-8"))
    }
}