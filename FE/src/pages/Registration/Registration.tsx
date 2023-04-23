import { Box } from "@mui/material";
import { Navbar } from "../../components/Navbar";
import styles from "./Registration.module.scss";
import { IntroSection } from "../../components/pages/Registration/IntroSection";

export function Registration() {
  return (
    <Box className={styles.registration}>
      <Navbar />
      <IntroSection />
    </Box>
  );
}
