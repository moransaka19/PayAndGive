package com.example.mobile.services

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.example.mobile.fragments.holder.ContainerHolder
import com.example.mobile.fragments.holder.PreorderHolder
import com.example.mobile.models.container.Container
import com.example.mobile.models.preorder.Preorder
import java.text.SimpleDateFormat

class PreorderAdapter(private val preorders: List<Preorder>) :
    RecyclerView.Adapter<PreorderHolder>() {

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): PreorderHolder {
        val layoutInflater = LayoutInflater.from(parent.context)

        return PreorderHolder(layoutInflater, parent)
    }

    override fun getItemCount(): Int {
        return preorders.size
    }

    override fun onBindViewHolder(holder: PreorderHolder, position: Int) {
        val preorder = preorders[position]
        holder.preorderDateTime.text = preorder.createdDateTime
        holder.preorderEatName.text = preorder.eat.name
        holder.preorderEatPrice.text = preorder.eat.price.toString()
    }
}
