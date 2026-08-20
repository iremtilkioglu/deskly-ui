document.addEventListener("DOMContentLoaded", function () {

    const textSlides = document.querySelectorAll("[data-slide-text]");
    const imageSlides = document.querySelectorAll("[data-slide-image]");
    const dots = document.querySelectorAll(".hero-dot");

    const mouseScene = document.getElementById("hero-mouse-scene");
    const mouseObject = document.getElementById("hero-mouse-object");

    const lampGlow = document.getElementById("hero-lamp-glow");
    const lampCone = document.getElementById("hero-lamp-light-cone");
    const lampBulb = document.getElementById("hero-lamp-bulb");
    const lampObject = document.getElementById("hero-lamp-object");
    const lampShadow = document.getElementById("hero-lamp-shadow");

    const infoSlides = document.querySelectorAll("[data-info-slide]");

    if (!textSlides.length || !imageSlides.length || !dots.length) return;

    let current = 0;
    const total = dots.length;
    let sliderInterval = null;
    let lampInterval = null;
    let infoIndex = 0;

    // HERO SLIDER
    function showSlide(index) {
        textSlides.forEach((slide, i) => {
            slide.classList.toggle("hidden", i !== index);
        });

        imageSlides.forEach((slide, i) => {
            const active = i === index;
            slide.classList.toggle("hidden", !active);
            slide.classList.toggle("flex", active);
        });

        dots.forEach((dot, i) => {
            if (i === index) {
                dot.classList.remove("w-2.5", "bg-[#AAB0B7]");
                dot.classList.add("w-8", "bg-[#3F5F7A]");
            } else {
                dot.classList.remove("w-8", "bg-[#3F5F7A]");
                dot.classList.add("w-2.5", "bg-[#AAB0B7]");
            }
        });

        current = index;
        handleLampAnimation();
    }

    function nextSlide() {
        showSlide((current + 1) % total);
    }

    function startSlider() {
        clearInterval(sliderInterval);
        sliderInterval = setInterval(nextSlide, 8000);
    }

    dots.forEach((dot, index) => {
        dot.addEventListener("click", function () {
            showSlide(index);
            startSlider();
        });
    });

    // MOUSE ANIMATION
    if (mouseScene && mouseObject) {
        let currentX = 0;
        let currentY = 0;
        let targetX = 0;
        let targetY = 0;
        let lastMouseX = 0;
        let lastMouseY = 0;
        let speedBoost = 0;
        let t = 0;

        mouseScene.addEventListener("mousemove", function (e) {
            if (window.innerWidth < 1024) return;

            const rect = mouseScene.getBoundingClientRect();
            const x = e.clientX - rect.left;
            const y = e.clientY - rect.top;

            const centerX = rect.width / 2;
            const centerY = rect.height / 2;

            const dx = x - centerX;
            const dy = y - centerY;

            const vx = e.clientX - lastMouseX;
            const vy = e.clientY - lastMouseY;
            const speed = Math.min(Math.sqrt(vx * vx + vy * vy), 35);
            speedBoost = speed * 0.9;

            let moveX = dx * 0.12;
            let moveY = dy * 0.10;

            const distance = Math.sqrt(dx * dx + dy * dy);
            if (distance < 140) {
                const angle = Math.atan2(dy, dx);
                const repelStrength = (140 - distance) * 0.22;
                moveX -= Math.cos(angle) * repelStrength;
                moveY -= Math.sin(angle) * repelStrength;
            }

            moveX += vx * 0.9;
            moveY += vy * 0.55;

            targetX = Math.max(Math.min(moveX, 55), -55);
            targetY = Math.max(Math.min(moveY, 45), -45);

            lastMouseX = e.clientX;
            lastMouseY = e.clientY;
        });

        mouseScene.addEventListener("mouseleave", function () {
            targetX = 0;
            targetY = 0;
            speedBoost = 0;
        });

        function animateMouse() {
            t += 0.04;

            if (current === 0 && window.innerWidth >= 1024) {
                currentX += (targetX - currentX) * 0.11;
                currentY += (targetY - currentY) * 0.11;

                const circleX = Math.cos(t) * 10;
                const circleY = Math.sin(t * 1.2) * 12;

                const rotate = currentX * 0.18 + Math.sin(t) * 3;
                const scale = 1 + Math.min(speedBoost / 220, 0.035);

                mouseObject.style.transform =
                    `translate(${currentX + circleX}px, ${currentY + circleY}px) rotate(${rotate}deg) scale(${scale})`;
            } else {
                currentX += (0 - currentX) * 0.08;
                currentY += (0 - currentY) * 0.08;

                const idleX = Math.cos(t) * 6;
                const idleY = Math.sin(t) * 8;

                mouseObject.style.transform =
                    `translate(${currentX + idleX}px, ${currentY + idleY}px)`;
            }

            requestAnimationFrame(animateMouse);
        }

        animateMouse();
    }

    // LAMP ANIMATION
    function handleLampAnimation() {
        if (!lampGlow || !lampCone || !lampBulb || !lampObject || !lampShadow) return;

        clearInterval(lampInterval);

        if (current !== 1) {
            lampGlow.style.opacity = "0";
            lampCone.style.opacity = "0";
            lampBulb.style.opacity = "0.2";
            return;
        }

        let lampOn = true;

        function toggleLamp() {
            if (lampOn) {
                lampGlow.style.opacity = "1";
                lampCone.style.opacity = "0.95";
                lampBulb.style.opacity = "1";
            } else {
                lampGlow.style.opacity = "0.2";
                lampCone.style.opacity = "0.1";
                lampBulb.style.opacity = "0.4";
            }
            lampOn = !lampOn;
        }

        toggleLamp();
        lampInterval = setInterval(toggleLamp, 1600);
    }

    // INFO GLASS PANEL ROTATOR
    const infoPanels = document.querySelectorAll("[data-info-panel]");

    if (infoPanels.length) {
        function showInfoPanel(index) {
            infoPanels.forEach((panel, i) => {
                const active = i === index;

                panel.classList.toggle("hidden", !active);
                panel.classList.toggle("flex", active);

                if (active) {
                    panel.style.animation = "none";

                    setTimeout(() => {
                        panel.style.animation = "infoDropIn 700ms cubic-bezier(0.22, 1, 0.36, 1) both";
                    }, 20);
                }
            });
        }

        showInfoPanel(0);

        setInterval(() => {
            infoIndex = (infoIndex + 1) % infoPanels.length;
            showInfoPanel(infoIndex);
        }, 3600);
    }

    showSlide(0);
    startSlider();
});