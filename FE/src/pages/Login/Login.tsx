import { Box } from "@mui/material";
import { Navbar } from "../../components/Navbar";
import { IntroSection } from "../../components/pages/Login/IntroSection";
import styles from "./Login.module.scss";

export function Login() {
  return (
    <Box className={styles.login}>
      <Navbar isHideButton />
      <IntroSection />
    </Box>
  );
}
