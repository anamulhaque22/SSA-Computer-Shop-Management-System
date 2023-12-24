import Image from "next/image";
import React from "react";

const CategoryItem = () => {
  return (
    <div className="border rounded flex justify-center flex-col items-center py-5">
      <Image
        src="/images/computer.png"
        alt="Picture"
        width={100}
        height={100}
        className="w-[148px] h-[148px]"
      />
      <h3 className="text-base font-medium">Computer & Laptop</h3>
    </div>
  );
};

export default CategoryItem;
