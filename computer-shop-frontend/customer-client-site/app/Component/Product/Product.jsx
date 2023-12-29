import Image from "next/image";
import Link from "next/link";
import React from "react";

const Product = () => {
  return (
    <div className="border p-5 flex flex-col items-center justify-center">
      <div>
        <Image
          src="/images/computer.png"
          width={202}
          height={172}
          alt="product"
        />
      </div>
      <div className="mt-4">
        <Link href={`product-details/1`} className="text-sm font-medium mb-5">
          TOZO T6 True Wireless Earbuds Bluetooth Headphon...
        </Link>
        <div className="flex justify-between items-center">
          <span className="text-base font-semibold">$39.99</span>
          <button className="cbtn px-3 py-2">Add To Cart</button>
        </div>
      </div>
    </div>
  );
};

export default Product;
