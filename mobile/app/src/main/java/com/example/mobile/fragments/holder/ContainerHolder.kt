package com.example.mobile.fragments.holder

import android.view.*
import android.widget.Button
import android.widget.CheckBox
import android.widget.CompoundButton
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.mobile.R
import com.example.mobile.models.container.Container

class ContainerHolder(
    layoutInflater: LayoutInflater,
    parent: ViewGroup
) : RecyclerView.ViewHolder(
    layoutInflater.inflate(R.layout.machine_container_item, parent, false)
) {
    var containerIdTextView: TextView = itemView.findViewById(R.id.container_id_text)
    var containerEatTextView: TextView = itemView.findViewById(R.id.container_eat_text)
    var containerPriceTextView: TextView = itemView.findViewById(R.id.container_price_text)
    var containerBookCheckBox: CheckBox =
        itemView.findViewById(R.id.container_book_checkbox)

    private lateinit var container: Container

    fun bind(container: Container, callback: (Container) -> Unit) {
        this.container = container
        containerIdTextView.text = this.container.id.toString()
        containerEatTextView.text = this.container.eat.name
        containerPriceTextView.text = this.container.eat.price.toString()
    }

}