import { Box } from "@mui/material";
import styles from "./Navbar.module.scss";

interface NavbarProps {
  isHideButton?: boolean;
}

export function Navbar({ isHideButton = false }: NavbarProps) {
  return (
    <Box className={styles.header}>
      <Box className="container">
        <Box className={styles.header_inner}>
          <Box className={styles.header_logo}>Test Platform</Box>
          {!isHideButton && (
            <button className={styles.header_btn} type="button">
              Sing In
            </button>
          )}
        </Box>
      </Box>
    </Box>
  );
}
