import React from "react";
import { Box } from "@mui/material";
import { Navbar } from "../../components/Navbar";
import { IntroSection } from "../../components/pages/Home/IntroSection";

export function Home() {
  return (
    <Box>
      <Navbar />
      <IntroSection />
    </Box>
  );
}
