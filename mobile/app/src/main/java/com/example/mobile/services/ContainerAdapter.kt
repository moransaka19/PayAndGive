package com.example.mobile.services

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.example.mobile.fragments.holder.ContainerHolder
import com.example.mobile.models.container.Container

class ContainerAdapter(private val containers: List<Container>, private val discount: Int) :
    RecyclerView.Adapter<ContainerHolder>() {
    var checkedContainers: ArrayList<Container> = ArrayList()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ContainerHolder {
        val layoutInflater = LayoutInflater.from(parent.context)

        return ContainerHolder(layoutInflater, parent)
    }

    override fun getItemCount(): Int {
        return containers.size
    }

    override fun onBindViewHolder(holder: ContainerHolder, position: Int) {
        val container = containers[position]
        var itemPrice = container.eat.price

        if(discount > 0){
            itemPrice = container.eat.price * discount / 100
        }

        holder.containerIdTextView.text = container.id.toString()
        holder.containerEatTextView.text = container.eat.name
        holder.containerPriceTextView.text = itemPrice.toString()
        holder.containerBookCheckBox.isChecked = false
        holder.containerBookCheckBox.setOnClickListener {
            checkedContainers.add(container)
        }
    }
}