document.addEventListener("DOMContentLoaded", () => {
  const buttons = document.querySelectorAll(".stat-button");

  buttons.forEach((button) => {
    button.addEventListener("click", () => {
      const info = button.nextElementSibling;
      if (info.style.display === "block") {
        info.style.display = "none";
      } else {
        info.style.display = "block";
      }
    });
  });
});
