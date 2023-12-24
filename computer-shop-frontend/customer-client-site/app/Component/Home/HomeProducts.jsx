"use client";
import React, { useState } from "react";
import Product from "../Product/Product";
const menuItem = [
  {
    id: 1,
    name: "All Product",
  },
  {
    id: 2,
    name: "Motherboard",
  },
  {
    id: 3,
    name: "RAM",
  },
  {
    id: 4,
    name: "Processor",
  },
  {
    id: 5,
    name: "Power Supply",
  },
  {
    id: 6,
    name: "Case",
  },
];
const HomeProducts = () => {
  const [categorySelected, setCategorySelected] = useState("All Product");
  return (
    <div className="container section-space mb-10">
      <div className="flex justify-between">
        <div className="">
          <h2 className="text-2xl font-semibold">Conputer Accessories</h2>
        </div>
        <div className="product-menu-list">
          <ul className="flex gap-x-5">
            {menuItem.map((item) => (
              <li key={item.id}>
                <a
                  className={`${
                    categorySelected === item.name ? "font-bold " : ""
                  } cursor-pointer`}
                  onClick={() => setCategorySelected(item.name)}
                >
                  {item.name}
                </a>
              </li>
            ))}
          </ul>
        </div>
      </div>

      <div className="grid grid-cols-4 gap-5 mt-5">
        <Product />
        <Product />
        <Product />
        <Product />
        <Product />
      </div>

      <div className="text-center mt-6">
        <a href="" className="cbtn px-4 py-3">
          Browse All Product
        </a>
      </div>
    </div>
  );
};

export default HomeProducts;
