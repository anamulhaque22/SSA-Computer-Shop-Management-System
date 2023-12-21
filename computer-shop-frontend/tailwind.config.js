/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./pages/**/*.{js,ts,jsx,tsx,mdx}",
    "./components/**/*.{js,ts,jsx,tsx,mdx}",
    "./app/**/*.{js,ts,jsx,tsx,mdx}",
  ],
  theme: {
    extend: {
      screens: {
        sm: "640px",

        md: "768px",

        lg: "1024px",

        xl: "1320px",

        "2xl": "1320px",
      },
      container: {
        center: true,
        padding: "1rem",
      },
      colors: {
        primary: "#FA8232",
      },
    },
  },
  plugins: [require("daisyui")],
  daisyui: {
    darkTheme: "white",
  },
};
