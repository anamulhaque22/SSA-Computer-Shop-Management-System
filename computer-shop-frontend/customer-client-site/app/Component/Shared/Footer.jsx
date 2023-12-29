import React from "react";

const Footer = () => {
  return (
    <div className=" bg-neutral">
      <footer className="container footer p-10 text-neutral-content">
        <nav>
          <header className="footer-title text-xl text-white uppercase">
            SSS
          </header>
          <div className="">
            <p>Customer Support:</p>
            <p>+880199999999</p>
            <p>Kuril, Dhaka</p>
            <p>info@kinbo.com</p>
          </div>
        </nav>
        <nav>
          <header className="footer-title uppercase">Top Category</header>
          <a className="link link-hover">About us</a>
          <a className="link link-hover">Contact</a>
          <a className="link link-hover">Jobs</a>
          <a className="link link-hover">Press kit</a>
        </nav>
        <nav>
          <header className="footer-title uppercase">Quick Link</header>
          <a className="link link-hover">Shopping Cart</a>
          <a className="link link-hover">Wishlist</a>
          <a className="link link-hover">Customer Help</a>
          <a className="link link-hover">About Us</a>
        </nav>
      </footer>
    </div>
  );
};

export default Footer;
