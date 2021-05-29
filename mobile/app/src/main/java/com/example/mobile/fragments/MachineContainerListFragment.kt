package com.example.mobile.fragments

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.mobile.R
import com.example.mobile.models.container.Container
import com.example.mobile.services.ContainerAdapter

class MachineContainerListFragment() : Fragment() {
    private lateinit var containerRecyclerView: RecyclerView
    private lateinit var adapter: ContainerAdapter
    private val containers: ArrayList<Container> = ArrayList()


    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        val view = inflater.inflate(R.layout.fragment_container_item_list, container, false)

        containerRecyclerView = view.findViewById(R.id.machine_container_recycle_view)
        containerRecyclerView.layoutManager = LinearLayoutManager(activity)
        adapter = ContainerAdapter(containers)
        containerRecyclerView.adapter = adapter

        return view
    }

    fun setContainers(containers: List<Container>) {
        this.containers.clear()
        this.containers.addAll(containers)
        adapter.notifyDataSetChanged()
    }
}