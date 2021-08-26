package com.example.mobile.fragments.holder

import android.view.LayoutInflater
import android.view.ViewGroup
import android.widget.CheckBox
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.mobile.R
import com.example.mobile.models.container.Container

class PreorderHolder(
    layoutInflater: LayoutInflater,
    parent: ViewGroup
) : RecyclerView.ViewHolder(
    layoutInflater.inflate(R.layout.preorder_item, parent, false)
) {
    var preorderDateTime: TextView = itemView.findViewById(R.id.preorder_datetime)
    var preorderEatName: TextView = itemView.findViewById(R.id.preorder_eat_name)
    var preorderEatPrice: TextView = itemView.findViewById(R.id.preorder_eat_price)
}