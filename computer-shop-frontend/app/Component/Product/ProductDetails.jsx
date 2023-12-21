"use client";
import Image from "next/image";
import React, { useState } from "react";

const ProductDetails = () => {
  const [quantity, setQuantity] = useState(1); // [1, function
  const handleQuantityIncrease = () => {
    setQuantity(quantity + 1);
  };
  const handleQuantityDecrease = () => {
    setQuantity(quantity - 1);
  };
  const handleOnChange = (e) => {
    setQuantity(e.target.value);
  };
  return (
    <div className="container mt-7">
      <div className="flex items-center gap-x-6">
        <div className="w-[45%] border">
          <Image
            src="/images/asus.webp"
            width={0}
            height={0}
            sizes="100vw"
            className="w-full h-[450px]"
            alt="product"
          />
        </div>
        <div className="w-[55%] pr-5">
          <h2>
            2020 Apple MacBook Pro with Apple M1 Chip (13-inch, 8GB RAM, 256GB
            SSD Storage) - Space Gray
          </h2>
          <div className="py-4">
            <div className="grid grid-cols-2">
              <span>ID: 2222</span>
              <span>
                Availability: <span className="text-[#2DB224]">In Stock</span>
              </span>
              <span>Brnad: Apple</span>
            </div>
            <h2 className="text-[#2DA5F3] font-semibold text-2xl mt-2">$555</h2>
          </div>
          <div className="flex gap-x-5">
            <div className="flex">
              <button
                className="border border-r-0 pl-5"
                onClick={handleQuantityDecrease}
              >
                -
              </button>
              <input
                type="number"
                value={quantity}
                onChange={handleOnChange}
                className="input input-bordered border-l-0 border-r-0 w-24 rounded-none"
              />
              <button
                className="border border-l-0 pr-5"
                onClick={handleQuantityIncrease}
              >
                +
              </button>
            </div>
            <button className="cbtn px-5">Add to card</button>
          </div>
        </div>
      </div>
      <div className="mt-8">
        <h4 className="text-base font-medium border py-3 px-5">Description</h4>
        <div className="p-5 border-l border-r border-b">
          <p>
            The most powerful MacBook Pro ever is here. With the blazing-fast M1
            Pro or M1 Max chip — the first Apple silicon designed for pros — you
            get groundbreaking performance and amazing battery life. Add to that
            a stunning Liquid Retina XDR display, the best camera and audio ever
            in a Mac notebook, and all the ports you need. The first notebook of
            its kind, this MacBook Pro is a beast. M1 Pro takes the exceptional
            performance of the M1 architecture to a whole new level for pro
            users. Even the most ambitious projects are easily handled with up
            to 10 CPU cores, up to 16 GPU cores, a 16‑core Neural Engine, and
            dedicated encode and decode media engines that support H.264, HEVC,
            and ProRes codecs.
          </p>
        </div>
        <p></p>
      </div>
    </div>
  );
};

export default ProductDetails;
