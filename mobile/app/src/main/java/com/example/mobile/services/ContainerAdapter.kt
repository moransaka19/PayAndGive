package com.example.mobile.services

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.example.mobile.fragments.holder.ContainerHolder
import com.example.mobile.models.container.Container

class ContainerAdapter(private val containers: List<Container>) :
    RecyclerView.Adapter<ContainerHolder>() {
    var list: List<Container>

    init {
        list = containers
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ContainerHolder {
        val layoutInflater = LayoutInflater.from(parent.context)

        return ContainerHolder(layoutInflater, parent)
    }

    override fun getItemCount(): Int {
        return containers.size
    }

    override fun onBindViewHolder(holder: ContainerHolder, position: Int) {
        val container = list[position]
        holder.bind(container, ::onItemChecked)
    }

    fun onItemChecked(container: Container) {
        list = list.map {
            if (it == container) {
                container.copy(isAdded = true)

            } else it
        }
        notifyDataSetChanged()
    }
}