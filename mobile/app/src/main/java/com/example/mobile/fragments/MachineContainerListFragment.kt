package com.example.mobile.fragments

import android.content.SharedPreferences
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import androidx.fragment.app.Fragment
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.mobile.R
import com.example.mobile.controllers.ContainerController
import com.example.mobile.controllers.ReceiptController
import com.example.mobile.models.container.Container
import com.example.mobile.services.ContainerAdapter
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class MachineContainerListFragment(private val token: String) : Fragment() {
    private lateinit var containerRecyclerView: RecyclerView
    private lateinit var buyButton: Button
    private lateinit var adapter: ContainerAdapter
    val containers: ArrayList<Container> = ArrayList()


    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        val view = inflater.inflate(R.layout.fragment_container_item_list, container, false)

        buyButton = view.findViewById(R.id.buy_button)
        buyButton.setOnClickListener {
            val controller = ReceiptController(token)
            controller.addReceipt(object : Callback<List<Container>> {
                override fun onResponse(
                    call: Call<List<Container>>,
                    response: Response<List<Container>>
                ) {
                    if (response.isSuccessful) {
                        var fragment =
                            supportFragmentManager.findFragmentById(R.id.container_fragment) as MachineContainerListFragment

                        fragment.setContainers(response.body()!!)
                    }
                }

                override fun onFailure(call: Call<List<Container>>, t: Throwable) {
                    TODO("Not yet implemented")
                }
            }, )
        }

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