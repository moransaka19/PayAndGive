package com.example.mobile.services

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.example.mobile.fragments.holder.ContainerHolder
import com.example.mobile.models.container.Container

class ContainerAdapter(private val containers: List<Container>) :
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

        holder.containerIdTextView.text = container.id.toString()
        holder.containerEatTextView.text = container.name
        holder.containerPriceTextView.text = container.price.toString()
        holder.containerBookCheckBox.isChecked = false
    }
}